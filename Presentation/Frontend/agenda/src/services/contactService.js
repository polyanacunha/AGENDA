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
        const response = await fetch(`${CONTACTS_ENDPOINT}/${id}`,{
            method: "GET",

            credentials: "include",
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
       
          credentials: "include",
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
          credentials: "include",
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
};

export default contactService;