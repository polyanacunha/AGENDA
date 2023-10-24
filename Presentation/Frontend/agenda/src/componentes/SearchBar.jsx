import React, { useState } from "react";
import "../styles/SearchBar.css";


const SearchBar = ({ onSearch }) => {
  const [searchTerm, setSearchTerm] = useState("");

  const handleSearch = () => {
    onSearch(searchTerm);
  };

  return (
    <div className="search-bar">
      <input
        type="text"
        placeholder="Digite sua pesquisa"
        value={searchTerm}
        onChange={(e) => setSearchTerm(e.target.value)}
      />
      <button className="searchButton" onClick={handleSearch}>Pesquisar</button>
    </div>
  );
};

export default SearchBar;
