import React, { useState, useEffect } from 'react';
import Chart from 'react-apexcharts';
import jsPDF from 'jspdf';
import 'jspdf-autotable';

const RelEntrada = () => {
    const [dadosGrafico, setDadosGrafico] = useState({
        series: [],
        options: {
            chart: {
                type: 'bar',
                height: 400,
                width: 600,
            },
            xaxis: {
                categories: [],
            },
        },
    });
    const [selectedDate, setSelectedDate] = useState('');

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch('https://localhost:7253/api/Entrada');
                const data = await response.json();

                const labels = [];
                const datasets = {};

                data.forEach((movimentacao) => {
                    const { mercadoriaId, dataHora } = movimentacao;

                    if (!labels.includes(dataHora)) {
                        labels.push(dataHora);
                    }

                    if (!datasets[mercadoriaId]) {
                        datasets[mercadoriaId] = Array(labels.length).fill(0);
                    }

                    const index = labels.indexOf(dataHora);
                    datasets[mercadoriaId][index]++;
                });

                const series = Object.entries(datasets).map(([mercadoriaId, data]) => ({
                    name: `Mercadoria ${mercadoriaId}`,
                    data,
                }));

                setDadosGrafico({
                    series,
                    options: {
                        chart: {
                            type: 'bar',
                            height: 400,
                            width: 600,
                        },
                        xaxis: {
                            categories: labels,
                        },
                    },
                });
            } catch (error) {
                console.error('Erro ao buscar movimentações:', error);
            }
        };

        fetchData();
    }, []);

    const handleGeneratePDF = async (data) => {
        
    };

    const handleDateChange = (e) => {
        setSelectedDate(e.target.value);

    };

    return (
        <div>
            <h2>Grafico de Entrada de Mercadorias</h2>
            <div>
                <input
                    type="date"
                    value={selectedDate}
                    onChange={handleDateChange}
                />
                <button onClick={handleGeneratePDF}>Gerar PDF</button>
                <Chart options={dadosGrafico.options} series={dadosGrafico.series} type="bar" height={400} width={600} />
            </div>
        </div>
    );
};

export default RelEntrada;
