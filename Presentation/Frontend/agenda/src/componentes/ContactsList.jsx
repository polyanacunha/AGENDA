import React, { useEffect, useState } from "react";
import "../styles/ContactsList.css";
import photo from "../utils/photo.png";
import trash from "../utils/trash.png";
import pencil from "../utils/pencil.png";
import { Link, BrowserRouter } from "react-router-dom";
// import { useNavigate } from "react-router-dom";
import contactService from "../services/contactService";
import { Route, Routes } from "react-router-dom";
import ContactRegister from "./ContactRegister";
import ContactEdit from "./ContactEdit";
import AppRoutes from "../Routes";
import App from "../App";
const ContactsList = () => {
  // const navigate = useNavigate();
  const [contacts, setContacts] = useState([]);
  // const handleContactRegisterClick = () => {
  //   navigate(`/contactRegister`);
  // };

  const fetchContacts = async () => {
    try {
      const data = await contactService.getContacts();
      setContacts(data);
      console.log({ contacts: data });
    } catch (error) {
      console.error("Erro ao obter os contatos:", error);
    }
  };

  useEffect(() => {
    fetchContacts();
  }, []);

  return (
    <>
      <div className="list-container">
        <h6 className="list-title">Contatos</h6>
        {contacts.map((contact) => (
          <div className="list-row" key={contact.id}>
            <div className="photo-container">
              <img src={photo} alt={contact.name} className="photo" />
            </div>
            <div className="name">{contact.name}</div>
            <button className="trash">
              <img src={trash} alt="" />
            </button>
            <Link
              to={`/Contacts/edit/${contact.id}`}
              className="card-buttons pencil"
            >
              <img src={pencil} alt="" />
            </Link>
          </div>
        ))}
      </div>
    </>
  );
};

export default ContactsList;
