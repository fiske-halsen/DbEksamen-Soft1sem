import React, { useState, useEffect } from "react";
import { URL } from "../settings";

function Login({ login }) {
  const init = { username: "Username", password: "Password" };
  const [loginCredentials, setLoginCredentials] = useState({ init });

  const performLogin = (evt) => {
    evt.preventDefault();
    login(loginCredentials.username, loginCredentials.password);
  };

  const onChange = (evt) => {
    setLoginCredentials({
      ...loginCredentials,
      [evt.target.id]: evt.target.value,
    });
  };

  return (
    <div>
      <h2>Login</h2>
      <form onChange={onChange}>
        <input placeholder="Username" id="username" />
        <input placeholder="Password" type="password" id="password" />
        <button onClick={performLogin}>Login</button>
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
