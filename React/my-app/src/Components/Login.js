import React, { useState, useEffect } from "react";
import { URL } from "../settings";
import apiFacade from "../apiFacade";

function Login({login}){
    const init = {username: "Username", password: "Password"}
    const [loginCredentials, setLoginCredentials] = useState({init})

    function performLogin(username, password){
        login(loginCredentials.username, loginCredentials.password);
    }

    const onChange = (evt) => {
        setLoginCredentials({
            ...loginCredentials,
            [evt.target.id]: evt.target.value,
        });
    }

    return (
        <div>
            <h2>Login</h2>
            <form onChange={onChange}>
                <input placeholder="Username" id="username"/>
                <input placeholder="Password" id="password"/>
                <button onClick={performLogin}>Login</button>
            </form>
        </div>
    )
}

function LoggedIn() {
    const [dataFromServer, setDataFromServer] = useState("Loading...");
  
    useEffect(() => {
        apiFacade.fetchData().then((data) => setDataFromServer(data.msg));
    }, [dataFromServer]);
  
    return (
      <div>
        <h2>Data Received from server</h2>
        <h3>{dataFromServer}</h3>
      </div>
    );
  }

export default Login;
export {LoggedIn};