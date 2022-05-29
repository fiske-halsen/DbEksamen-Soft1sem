import './App.css';
import Header from "./Components/Header";
import Customer from "./Components/Customer"
import Owner from "./Components/Owner"
import Register from "./Components/Register"
import Restaurants from "./Components/Restaurants"
import RestaurantMenu from "./Components/RestaurantMenu"
import Login, { LoggedIn } from "./Components/Login";
import loginIdentity from "./apiFacade"

import React, {
  useState
} from "react";
import {
  Routes,
  Route,
  BrowserRouter
} from "react-router-dom";

function App() {
  const [loggedIn, setLoggedIn] = useState(false);
  const [error, setError] = useState("");
  //const [role, setRole] = useState("");

  const logout = () => {
   // apiFacade.logout();
    setLoggedIn(false);
  };

  const login = (user, pass) => {
      login(user, pass)
      .then((res) => setLoggedIn(true), setError(""))
      .catch((err) => {
        setError("Wrong username or password");
      });
  };

  return (
    <div>
    <Header></Header>
   
   <Routes>
     

     
            
           
              
      </Routes>


      </div>

    );
  }
  export default App;
