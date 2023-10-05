import React, { useEffect, useState } from "react";
import "../styles/ContactsList.css";
import photo from '../utils/photo.png';
import trash from '../utils/trash.png';
import pencil from '../utils/pencil.png';



const ContactsList = () => {
  const [contacts, setContacts] = useState([]);

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
      
        {contacts.map((contact) => (
          <div className="list-row" key={contact.id}>
            <div className="photo-container">
              <img src={contact.foto} alt={contact.nome} className="photo" />
            </div>
          </div>
        ))}
      </div>
    </>
  );
};

export default ContactsList;
