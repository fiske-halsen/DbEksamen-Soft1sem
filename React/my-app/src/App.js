import "./App.css";
import Header from "./Components/Header";
import Customer from "./Components/Customer";
import Owner from "./Components/Owner";
import Register from "./Components/Register";
import Restaurants from "./Components/Restaurants";
import RestaurantMenu from "./Components/RestaurantMenu";
import Login, { LoggedIn } from "./Components/Login";
import { facade } from "./apiFacade";

import React, { useState } from "react";
import { Routes, Route, BrowserRouter } from "react-router-dom";

function App() {
  const [loggedIn, setLoggedIn] = useState(false);
  const [error, setError] = useState("");
  //const [role, setRole] = useState("");

  const logout = () => {
    facade.logout();
    setLoggedIn(false);
  };

  function fetchAllRest () {
    facade.fetchAllRest();
  };

  function login(user, pass) {
    facade
      .login(user, pass)
      .then((res) => setLoggedIn(true), setError(""))
      .catch((err) => {
        err.fullError.then((e) => setError(e.message));
      });
  }

  return (
    <div>
      <Header></Header>
      <Routes>
        <Route exact path="/"></Route>
        <Route path="/restaurants" element={<Restaurants  />}>
          <Route path=":restaurantId" element={<RestaurantMenu />} />
        </Route>





        {!loggedIn ? (
          <Route exact path="/login" element={<Login login={login} />} />
        ) : (
          <Route exact path="/login" element={<LoggedIn logout={logout} />} />
        )}
        
      </Routes>
    </div>
  );
}
export default App;
