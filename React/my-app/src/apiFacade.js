import { URL } from "./settings.js";

function handleHttpErrors(res) {
  if (!res.ok) {
    return Promise.reject({ status: res.status, fullError: res.json() });
  }
  return res.json();
}

export default function apiFacade() {
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

  const login = (user, password) => {
    const options = makeOptions("POST", true, {
      username: user,
      password: password,
    });

    return fetch(URL + "/api/login", options)
      .then(handleHttpErrors)
      .then((res) => {
        setToken(res.token);
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

  return {
    makeOptions,
    setToken,
    getToken,
    loggedIn,
    login,
    logout,
    fetchData,
    getRole,
    fetchContacts,
    createContact,
    findContact,
    editContact,
    deleteContact,
    addOpportunity,
    getOpportunitiesFromContact,
  };
}