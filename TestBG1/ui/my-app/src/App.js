import logo from './logo.svg';
import './App.css';
import {Home} from './Home';
import {Department} from './Department';
import {BrowserRouter, Router, Switch, NavLink } from 'react-router-dom';
function App() {
  return (

    <BrowserRouter>
    <div className="App container">
       <h3 className="d-flex justify-content-center m-3">
          Probando Codigo Con Boostrap + React Native  
       </h3>
      
       <nav className='navbar navbar-expand-sm bg-light navbar-dark'>
          <ul className="navbar-nav">
           <li className="nav-item- m-1">
              <NavLink className="btn btn-ligh btn-outline-primary" to="/home">
                Home
              </NavLink>
          </li>  
          <li className="nav-item- m-1">
              <NavLink className="btn btn-ligh btn-outline-primary" to="/department">
                Department
              </NavLink>
          </li>  
          </ul>

       </nav>
        <Switch>
          <Router path='./home' componet={Home}/>
          <Router path='./department' componet={Department}/>
        </Switch>

    </div>
    </BrowserRouter>
  );
}

export default App;
