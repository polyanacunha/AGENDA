import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import "../styles/ContactEdit.css";
import contactService from "../services/contactService";
import { Link } from "react-router-dom";

const ContactEdit = () => {
  const navigate = useNavigate();
  const [contact, setContact] = useState([]);
  const [name, setName] = useState("");
  const [telephone, setTelephone] = useState("");
  const [email, setEmail] = useState("");
  const [description, setDescription] = useState("");
  const [image, setImage] = useState(null);
  const [synced, setSynced] = useState(false);

  let { id } = useParams();
  const syncContactWithId = async () => {
    const contactId = id;
    console.log({ id: contactId });
   
    try {
      const contactData = await contactService.getContactById(contactId);
      setContact(contactData);
      setName(contactData.name);
      setTelephone(contactData.telephone);
      setEmail(contactData.email);
      setDescription(contactData.description);
      setImage(contactData.image);
      // <Link to={`/contactEdit?redirectTo=edit&id=${contactId}`} className="card-buttons"></Link>
    } catch (error) {
      console.error("Error fetching contact:", error);
      // navigate(`/?redirectTo=edit&id=${contactId}`);
      // <Link to={`/contactEdit?redirectTo=edit&id=${contactId}`} className="card-buttons"></Link>
    }
  };
  useEffect(() => {
    syncContactWithId();
  }, [synced]);

  const handleSubmit = async (event) => {
    event.preventDefault();
    const contactData = {
      id: id,
      name: name,
      telephone: telephone,
      email: email,
      description: description,
      image: image 
    
  };
    const response = await contactService.editContact(id, contactData);
    alert("salvo com sucesso");
    navigate(`/Contacts/list`);
  };

  return (
    <div className="edit-container">
      {name && (
        <>
          <h3 className="edit-title">Editar Contato</h3>
          <hr className="edit-divider" />
          <div className="row">
            <div className="col-md-4">
              <form className="edit-form" onSubmit={handleSubmit}>
                <div className="form-group">
                  <label className="control-label">Nome:</label>
                  <input
                    className="form-control"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                  />
                  <label className="control-label">Telefone:</label>
                  <input
                    className="form-control"
                    value={telephone}
                    onChange={(e) => setTelephone(e.target.value)}
                  />
                  <label className="control-label">Email:</label>
                  <input
                    className="form-control"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                  />
                  <label className="control-label">Descrição:</label>
                  <input
                    className="form-control"
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                  />
                  <span className="text-danger"></span>
                </div>
                <div className="form-group">
                  <input
                    type="submit"
                    value="Save"
                    className="edit-button btn btn-primary"
                  />
                </div>
              </form>
            </div>
          </div>
        </>
      )}
    </div>
  );
};

export default ContactEdit;
