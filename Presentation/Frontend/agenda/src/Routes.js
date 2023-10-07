import React from 'react';
import { Route, Routes} from 'react-router-dom';
import ContactRegister from './components/ContactRegister';
import ContactsList from './componentes/ContactsList';


function AppRoutes() {
    return (
      <>
      <Routes>
        <Route path="/contactRegister" element={<ContactRegister/>} />
        <Route path="/contactList" element={<ContactsList/>}/>
      </Routes>
      </>
    );
  }
  
  export default AppRoutes;