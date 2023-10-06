import React, { useEffect, useState } from "react";
import "../styles/ContactsList.css";
import photo from '../utils/photo.png';
import trash from '../utils/trash.png';
import pencil from '../utils/pencil.png';
// import { Link } from "react-router-dom";
// import { useNavigate } from "react-router-dom";
import contactService from "../services/contactService";


const ContactsList = () => {
  // let navigate = useNavigate();
  const [contacts, setContacts] = useState([]);

  // const handleContactRegister = () => {
  //   navigate(`/contactRegister`);
  // };

  const fetchContacts = async () => {
    try {
      const data = await contactService.getContacts();
    } catch (error) {
      console.error("Erro ao obter os contatos:", error);
    }
  };

  useEffect(() => {
    fetchContacts()
  }, []);

  return (
    <>
      <div className="list-container">
        <h6 className="list-title">Contatos</h6>
        <div className="list-row">
          <div className="photo-container">
            <img src={photo} alt={contacts.nome} className="photo" />
          </div>
          <div className="name">Polyana Cunha</div>
          <button className="trash">
            <img src={trash} alt="" />
          </button>
          <button className="pencil">
            <img src={pencil} alt="" />
          </button>

        </div>
         <div className="list-row">
          <div className="photo-container">
            <img src={photo} alt={contacts.nome} className="photo" />
          </div>
          <div className="name">Polyana Cunha</div>
          <button className="trash">
            <img src={trash} alt="" />
          </button>
          <button className="pencil">
            <img src={pencil} alt="" />
            
          </button>
        </div> 
         <button className="card-buttons">
            {/* <Link to={`/contactRegister`} className="button edit-button">
            CREATE CONTACT
            </Link>  */}
         </button>
        {/* {contacts.map((contact) => (
          <div className="list-row" key={contact.id}>
            <div className="photo-container">
              <img src={contact.foto} alt={contact.nome} className="photo" />
            </div>
          </div>
        ))} */}
      </div>
    </>
  );
};

export default ContactsList;
