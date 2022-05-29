import './App.css';
import Header from "./Components/Header";
import Customer from "./Components/Customer"
import Owner from "./Components/Owner"
import Register from "./Components/Register"
import Restaurants from "./Components/Restaurants"
import RestaurantMenu from "./Components/RestaurantMenu"
import Login, { LoggedIn } from "./Components/Login";
import {facade} from "./apiFacade"

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

 function login (user, pass)  {
  facade
  .login(user, pass)
  .then((res) => setLoggedIn(true), setError(""))
  .catch((err) => {
    err.fullError.then((e) => setError(e.message));
  });
  };

  return (
    <div>
    <Header></Header>
   <Routes>
   <Route exact path="/">
        </Route>
        {!loggedIn ? (
            <Route exact path="/login" element={<Login login={login} />}>
            </Route>
        ) : (
              <Route exact path="/login" element={<LoggedIn />}>
              </Route>
        )}
      </Routes>
      </div>

    );
  }
  export default App;
