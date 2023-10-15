import { Link , BrowserRouter} from "react-router-dom";
import "../styles/Home.css";
import { Route, Routes} from 'react-router-dom';
import ContactsList from './ContactsList';
import AppRoutes from '../Routes';

const Home = () => {
  return (
    <div className="main-container">
      
      <button className="button-home">
        {/* <Link to={`/contactsList`} className="card-buttons">
          Go to contacts list
        </Link> */}
      </button>

    </div>
  );
};

export default Home;
