import { CONTACTS_ENDPOINT } from "./apiConfig";

const contactService = {

    getContacts: async () => {
        try {
            const response = await fetch(CONTACTS_ENDPOINT, {
                method: "GET",
                mode: "cors",
                headers: {
                    Accept: "application/json",
                    "Access-Control-Allow-Origin":"*"

                }
            });
            if (!response.ok) {
                throw new Error("Falha ao obter os contatos");
            }
            const data = await response.json();
            return data;
        } catch (error) {

            console.error("Erro ao obter os contatos", error);
            throw error;
        }
    },
    getContactById: async(id) => {
        console.log({serviceid:id});
        const response = await fetch(`${CONTACTS_ENDPOINT}/${id}`,{
            method: "GET",
        });
        if (!response.ok) {
            throw new Error("Falha ao obter os contatos");
          }
          console.log({ getSucced: "getcontact by id" });

          const data = await response.json();
          return data;
    },
    deleteContact: async (id) => {
    
        const response = await fetch(`${CONTACTS_ENDPOINT}/${id}`, {
          method: "DELETE",
       
        });
        if (!response.ok) {    
          throw new Error("Falha ao deletar o contato");
        }
    
        console.log({ deleteSucced: "deletado com sucesso" });
    
        const data = await response.json();
        return data;
      },
      createNewContact: async (newContactData) => {
        const response = await fetch(CONTACTS_ENDPOINT, {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(newContactData),
        });
        if (!response.ok) {    
          console.log({ newContactData: newContactData });
    
          throw new Error("Falha ao criar novo contato");
        }
    
        console.log({ createSucced: "contato criado com sucesso" });
    
        const data = await response.json();
        return data;
      },
      editContact: async (id, updatedContactData) => {
        try {
          const response = await fetch(`${CONTACTS_ENDPOINT}/${id}`, {
            method: "PUT",
            headers: {
              "Accept": "application/json",
              "Content-Type": "application/json",
          },          
            body: JSON.stringify(updatedContactData),
          });
    
          if (!response.ok) {
            throw new Error("Falha ao editar o contato");
          }
    
          console.log({ editSucced: "Contato editado com sucesso" });
    
          const data = await response.json();
          return data;
        } catch (error) {
          console.error("Erro ao editar o contato", error);
          throw error;
        }
      },
      
};

export default contactService;