import SideBar from './components/SideBar';
import Home from './pages/Home';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import ListaFabricante from './pages/ListaFabricante';
import ListaTipoMercadoria from './pages/ListaTipoMercadoria';
import ListaMercadoria from './pages/ListaMercadoria';
import DelFabricante from './pages/DelFabricante';
import AddFabricante from './pages/AddFabricante';
import AddTipoMercadoria from './pages/AddTipoMercadoria';
import AddMercadoria from './pages/AddMercadoria';
import DelTipoMercadoria from './pages/DelTipoMercadoria';
import AddEntrada from './pages/AddEntrada';
import AddSaida from './pages/AddSaida';
import RelSaida from './pages/RelSaida';
import RelEntrada from './pages/RelEntrada';

function App() {
    return (
        <Router>
            <div className="App">
                <SideBar />
                <div className="content">
                    <Routes>
                        <Route exact path="/" element={<Home />} />
                        <Route path="/listaFabricante" element={<ListaFabricante />} />
                        <Route path="/listaTipoMercadoria" element={<ListaTipoMercadoria />} />
                        <Route path="/listaMercadoria" element={<ListaMercadoria />} />
                        <Route path="/delFabricante/:id" element={<DelFabricante />} />
                        <Route path="/delTipoMercadoria/:id" element={<DelTipoMercadoria />} />
                        <Route path="/addFabricante" element={<AddFabricante />} />
                        <Route path="/addTipoMercadoria" element={<AddTipoMercadoria />} />
                        <Route path="/addMercadoria" element={<AddMercadoria />} />
                        <Route path="/addEntrada" element={<AddEntrada />} />
                        <Route path="/addSaida" element={<AddSaida />} />
                        <Route path="/relSaida" element={<RelSaida />} />
                        <Route path="/relEntrada" element={<RelEntrada />} />
                    </Routes>
                </div>
            </div>
        </Router>
    );
}

export default App;
