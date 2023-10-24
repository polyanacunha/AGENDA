import { Link , BrowserRouter} from "react-router-dom";
import "../styles/Delete.css";
import { Route, Routes} from 'react-router-dom';
import ContactsList from './ContactsList';
import AppRoutes from '../Routes';
import { useNavigate, useParams  } from "react-router-dom";
import React, { useEffect, useState } from "react";
import contactService from "../services/contactService";


const Delete = (props) => {
  const navigate = useNavigate();
  const [logged, setLogged] = useState(null);
  const [contact, setContact] = useState([]);
  let { id } = useParams();



  const DeleteContactById = async () => {
    const contactId = id;

    try {
        const contactData = await contactService.deleteContact(
          contactId,
        );
        setLogged(true);
        setContact(contactData);
      } catch (error) {
        console.error("error deleting contact", error);
        navigate(`/Contacts/delete/${contactId}`);
      } 
    }
  
  useEffect(() => {
    DeleteContactById();
  }, []);
  useEffect(() => {}, [contact]);



  const handleSubmit = (event) => {
    event.preventDefault();
  };

  const handleSucessDeleted = () => {
    alert("Contato deletado com sucesso!")
  };
  return (


    <div className="main-container">
      <form className="delete-form" onSubmit={handleSubmit}>

        <h1>Tem certeza de que deseja deletar esse contato?</h1>

 
   <button className="button-home">
        <Link to={`/Contacts/list`} className="card-buttons">
          NÃO
        </Link>
      </button>
      
      <button className="button-home" onClick={handleSucessDeleted}>
        <Link to={`/Contacts/list`} className="card-buttons">
          SIM
        </Link>
      </button>
 </form>
    </div>
  );
};

export default Delete;
