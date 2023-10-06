import React, { useEffect, useState } from "react";




const ContactRegister = () => {
  const [name, setName] = useState("");
  const [telefone, setTelefone] = useState("");
  const [email, setEmail] = useState("");
  const [description, setDescription] = useState("");
  const [image, setImage] = useState("");


  const CreateNewContact = async () => {
    const contactData = {
      nome: name, 
      telefone: telefone,
      descricao: description,
      email: email,
      foto: image,

    };

    try {
      const response = await contactService.CreateNewContact(contactData);
      alert("Contato cadastrado com sucesso!")

    }catch(error) {
      Navigate(`/contactRegister`);
    }

  };

  const handleBackToList = () => {
    navigate(`/contactList`);
  };
  return (
    <div className="contact-register-container">
    
      <form className="contact-register-form" onSubmit={handleSubmit}>
        <h2 className="form-title">Criar novo contato</h2>

        <div className="form-group">
          <label htmlFor="name" className="form-label">
            Nome
          </label>
          <input
            id="name"
            type="text"
            className="form-input"
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
        </div>
        <div className="form-group">
          <label htmlFor="telefone" className="form-label">
            Telefone
          </label>
          <input
            id="telefone"
            type="text"
            className="form-input"
            value={telefone}
            onChange={(e) => setTelefone(e.target.value)}
          />
        </div>
        <div className="form-group">
          <label htmlFor="description" className="form-label">
            Descrição
          </label>
          <input
            id="description"
            type="text"
            className="form-input"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
          />
        </div>
        <div className="form-group">
          <label htmlFor="email" className="form-label">
            Email
          </label>
          <input
            id="email"
            type="text"
            className="form-input"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </div>
        <div className="form-group">
          <label htmlFor="foto" className="form-label">
            Foto
          </label>
          <input
            id="photo"
            type="text"
            className="form-input"
            value={image}
            onChange={(e) => setImage(e.target.value)}
          />
        </div>
        <div className="form-buttons">
          <button
            className="form-button btn btn-primary"
            onClick={() => {
              CreateNewContact();
              handleBackToList();
            }}
          >
            Registrar
          </button>
          <button
            className="form-button btn btn-primary"
            onClick={() => handleBackToList()}
          >
            Voltar para a lista
          </button>
        </div>
      </form>

    </div>
  );

}

export default ContactRegister;
