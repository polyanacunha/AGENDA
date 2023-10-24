import { Link, BrowserRouter } from "react-router-dom";
import "../styles/Navbar.css";
import SearchBar from "./SearchBar";

const Navbar = () => {
  return (
    <>
    <SearchBar/> 
    <div className="container">
      <button className="createnewcontact">
        <Link to={`/Contacts/register`} className="button edit-button">
          Criar novo contato
        </Link>
      </button>
    </div>
    </>
  );
};

export default Navbar;
