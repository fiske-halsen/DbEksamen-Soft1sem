import React, { useState, useEffect } from "react";
import { URL } from "../settings";
import {facade} from "../apiFacade.js";

function Login({ login }) {
  const init = { username: "Username", password: "Password" };
  const registerInit = {
    name: "",
    lastName: "", 
    phone: "",
    email: "",
    password: "",
    passwordRepeated: ""
  }

  const [loginCredentials, setLoginCredentials] = useState({ init });
  const [registerCredentails, setRegisterCredentails] = useState({ registerInit });

  const performLogin = (evt) => {
    evt.preventDefault();
    console.log(loginCredentials)    
    login(loginCredentials.username, loginCredentials.password);
  };

  const performRegister = (evt) => {
    evt.preventDefault();
    facade.register(registerCredentails);
    setRegisterCredentails(registerInit)
  }

  const onChangeLogin = (evt) => {
    setLoginCredentials({
      ...loginCredentials,
      [evt.target.id]: evt.target.value,
    });
  };

  const onChangeRegister = (evt) => {
    setRegisterCredentails({
      ...registerCredentails,
      [evt.target.id]: evt.target.value,
    });
    console.log(registerCredentails)
  };


  return (
    <div>
      <h2>Login</h2>
      <form onChange={onChangeLogin}>
      <b> Email</b>
      <br></br>
        <input placeholder="Username" id="username" />
        <br></br>
        <br></br>
        <b> Password</b>
        <br></br>
        <input placeholder="Password" type="password" id="password" />
        <br></br>
        <br></br>
        <button onClick={performLogin}>Login</button>
      </form>

      <div>

    </div>
    <h2>Register</h2>
      <form onChange={onChangeRegister}>
        <b> Name</b>
        <br></br>
        <input placeholder="First Name" id="name" type="text" />
        <br></br>
        <br></br>
        <b> LastName</b>
        <br></br>
        <input placeholder="Last name" type="text" id="lastName" />
        <br></br>
        <br></br>
        <b> Phone</b>
        <br></br>
        <input placeholder="Phone" type="text" id="phone" />
        <br></br>
        <br></br>
        <b> Email</b>
        <br></br>
        <input placeholder="Email Address" type="email" id="email" />
        <br></br>
        <br></br>
        <b> Password</b>
        <br></br>
        <input placeholder="Password" type="password" id="password" />
        <br></br>
        <br></br>
        <b> Confirm password</b>
        <br></br>
        <input placeholder="ConfirmPassword" type="password" id="passwordRepeated" />
        <br></br>
        <br></br>
        <button onClick={performRegister}>Register</button>
      </form>
    </div>
  );
}

function LoggedIn({ logout }) {
  const [dataFromServer, setDataFromServer] = useState("Loading...");

  useEffect(() => {
    //apiFacade.fetchData().then((data) => setDataFromServer(data.msg));
  }, [dataFromServer]);

  const performLogout = (evt) => {
    evt.preventDefault();
    logout();
  };

  return (
    <div>
      <h2>Data Received from server</h2>
      <h3>{dataFromServer}</h3>
      <button onClick={performLogout}>Logout</button>
    </div>
  );
}

export default Login;
export { LoggedIn };
