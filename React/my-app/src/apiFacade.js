import { URL } from "./settings.js";

function handleHttpErrors(res) {
  if (!res.ok) {
    return Promise.reject({ status: res.status, fullError: res.json() });
  }
  return res.json();
}
  /* Insert utility-methods from a latter step (d) here (REMEMBER to uncomment in the returned object when you do)*/
  const setToken = (token) => {
    localStorage.setItem("jwtToken", token);
  };

  const getToken = () => {
    return localStorage.getItem("jwtToken");
  };

  const loggedIn = () => {
    const loggedIn = getToken() != null;

    return loggedIn;
  };

  const logout = () => {
    localStorage.removeItem("jwtToken");
  };

export default function login (userName, password)  {

  const formData = new URLSearchParams();
  formData.append('grant_type', 'password');
  formData.append('client_id', 'ApiGateWayClient');
  formData.append('client_secret', '86d677d3-ffee-4a6d-85ab-e000894768e6');
  formData.append('scope', 'GatewayServiceAPI');
  formData.append('username', userName);
  formData.append('password', password);

    return fetch(`https://localhost:7292/connect/token`, {
      method: 'POST',
      headers: {
        // "Content-Type": "application/json; charset=utf-8",
        "Content-Type": "application/x-www-form-urlencoded",
    },
      body: formData.toString(),
      json: true,
    })
      .then(handleHttpErrors)
      .then((res) => {
        console.log(res)
        setToken(res.access_token);
      });
  };

  const getRole = () => {
    let myToken = getToken();
    let tokenData = myToken.split(".")[1];
    let decoedeJsonData = window.atob(tokenData);
    let decodedJwtData = JSON.parse(decoedeJsonData);
    let role = decodedJwtData.roles;
    console.log(role);

    return role;
  };

  const fetchData = () => {
    const options = makeOptions("GET", true); //True add's the token

    let role = getRole();

    return fetch(URL + "/api/contact/" + role, options).then(handleHttpErrors);
  };

  const fetchContacts = () => {
    const options = makeOptions("GET", true);

    return fetch(URL + "/api/contact/all", options).then(handleHttpErrors);
  };

  const createContact = (body) => {
    const options = makeOptions("POST", true, body);

    return fetch(URL + "/api/contact/create", options).then(handleHttpErrors);
  };

  const findContact = (id) => {
    const options = makeOptions("GET", true);

    return fetch(URL + "/api/contact/get/" + id, options).then(
      handleHttpErrors
    );
  };

  const editContact = (body) => {
    const options = makeOptions("PUT", true, body);

    return fetch(URL + "/api/contact/edit", options).then(handleHttpErrors);
  };

  const deleteContact = (id) => {
    const options = makeOptions("DELETE", true);

    return fetch(URL + "/api/contact/delete/" + id, options).then(
      handleHttpErrors
    );
  };

  const addOpportunity = (body, id) => {
    const options = makeOptions("PUT", true, body);

    return fetch(URL + "/api/contact/addOpportunity/" + id, options).then(
      handleHttpErrors
    );
  };

  const getOpportunitiesFromContact = (id) => {
    const options = makeOptions("GET", true);

    return fetch(URL + "/api/contact/getOpportunities/" + id, options).then(
      handleHttpErrors
    );
  };

  const makeOptions = (method, addToken, body) => {
    var opts = {
      method: method,
      headers: {
        "Content-type": "application/json",
        Accept: "application/json",
      },
    };
    if (addToken && loggedIn()) {
      opts.headers["x-access-token"] = getToken();
    }
    if (body) {
      opts.body = JSON.stringify(body);
    }
    return opts;
  };



