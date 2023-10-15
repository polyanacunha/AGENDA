import ContactsList from './componentes/ContactsList';
import ContactRegister from './componentes/ContactRegister';
import './App.css';
import AppRoutes from "./Routes";
import { BrowserRouter as Router } from "react-router-dom";
import Home from './componentes/Home';
import { Route, Routes} from 'react-router-dom';

const App = () => {

  return (
    <>
    <Router>
        <AppRoutes />
    </Router>
    {/* <Home/> */}
    
  </>
  );
};

export default App;
