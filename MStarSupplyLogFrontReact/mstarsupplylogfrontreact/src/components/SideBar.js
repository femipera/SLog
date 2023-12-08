import React, { useState } from 'react';
import { Link } from 'react-router-dom';

const Sidebar = () => {
    const [activeSubMenu1, setActiveSubMenu1] = useState(null);
    const [activeSubMenu2, setActiveSubMenu2] = useState(null);
    const [activeSubMenu3, setActiveSubMenu3] = useState(null);

    const handleSubMenuClick = (index) => {
        if (index === 1) {
            setActiveSubMenu1(activeSubMenu1 === index ? null : index);
        } else if (index === 2) {
            setActiveSubMenu2(activeSubMenu2 === index ? null : index);
        } else if (index === 3) {
            setActiveSubMenu3(activeSubMenu3 === index ? null : index);
        }
    };

    return (
        <div className="sidebar">
            <div className="header">
                <h3>MStarSupply</h3>
            </div>
            <ul className="menu">
                <li>
                    <Link to="/">Home</Link>
                </li>
                <li className="submenu-parent">
                    <a href="#" onClick={() => handleSubMenuClick(1)}>
                        Cadastros
                        {activeSubMenu1 === 1 ? <span className="submenu-indicator">&#9650;</span> : <span className="submenu-indicator">&#9660;</span>}
                    </a>
                    <ul className={activeSubMenu1 === 1 ? 'submenu active' : 'submenu'}>
                        <li><Link to="/listaFabricante">Fabricante</Link></li>
                        <li><Link to="/listaMercadoria">Mercadoria</Link></li>
                        <li><Link to="/listaTipoMercadoria">Tipo Mercadoria</Link></li>
                    </ul>
                </li>
                <li className="submenu-parent">
                    <a href="#" onClick={() => handleSubMenuClick(2)}>
                        Movimenta&ccedil;&otilde;es
                        {activeSubMenu2 === 2 ? <span className="submenu-indicator">&#9650;</span> : <span className="submenu-indicator">&#9660;</span>}
                    </a>
                    <ul className={activeSubMenu2 === 2 ? 'submenu active' : 'submenu'}>
                        <li><Link to="/addEntrada">Entradas</Link></li>
                        <li><Link to="/addSaida">Sa&iacute;das</Link></li>
                    </ul>
                </li>
                <li className="submenu-parent">
                    <a href="#" onClick={() => handleSubMenuClick(3)}>
                        Relat&oacute;rios
                        {activeSubMenu3 === 3 ? <span className="submenu-indicator">&#9650;</span> : <span className="submenu-indicator">&#9660;</span>}
                    </a>
                    <ul className={activeSubMenu3 === 3 ? 'submenu active' : 'submenu'}>
                        <li><Link to="/relEntrada">Entradas</Link></li>
                        <li><Link to="/relSaida">Sa&iacute;das</Link></li>
                    </ul>
                </li>
            </ul>
        </div>
    );
};

export default Sidebar;
