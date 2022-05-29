import './App.css';
import Header from "./Components/Header";
import Customer from "./Components/Customer"
import Owner from "./Components/Owner"
import Register from "./Components/Register"
import Restaurants from "./Components/Restaurants"
import RestaurantMenu from "./Components/RestaurantMenu"
import Login, { LoggedIn } from "./Components/Login";
import apiFacade from "./apiFacade"
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
    apiFacade.logout();
    setLoggedIn(false);
  };

  const login = (user, pass) => {
    apiFacade
      .login(user, pass)
      .then((res) => setLoggedIn(true), setError(""))
      .catch((err) => {
        setError("Wrong username or password");
      });
  };

  return (
        <Routes>
          {!loggedIn ? (
            <Route exact path="/" element={
              <Login login={login} animate={true}/>
            
          }/>
        ) : (
          <Route exact path="/" element={<LoggedIn/>}/>
        )}
        </Routes>
    );
  }
  export default App;
