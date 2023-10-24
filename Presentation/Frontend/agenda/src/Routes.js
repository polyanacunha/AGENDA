import React from 'react';
import { Route, Routes, Router} from 'react-router-dom';
import ContactRegister from './componentes/ContactRegister';
import ContactsList from './componentes/ContactsList';
import ContactEdit from './componentes/ContactEdit';
import ContactDelete from './componentes/ContactDelete';
import { BrowserRouter } from "react-router-dom";
import Home from './componentes/Home';

function AppRoutes() {
    return (
      <>      
      <Routes>
        <Route path="Contacts">
          <Route path="register" element={<ContactRegister/>} />
          <Route path="list" element={<ContactsList/>}/>
          <Route path="edit/:id" element={<ContactEdit/>}/>
          <Route path="delete/:id" element={<ContactDelete/>}/>
        </Route>
      </Routes> 
      </>
    );
  }
  
  export default AppRoutes;