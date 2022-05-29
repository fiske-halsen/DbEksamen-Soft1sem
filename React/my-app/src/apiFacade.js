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
console.log(loggedIn)
  return loggedIn;
};

const logout = () => {
  localStorage.removeItem("jwtToken");
};

async function login(userName, password) {
  const formData = new URLSearchParams();
  console.log('userName', userName)
  formData.append("grant_type", "password");
  formData.append("client_id", "ApiGateWayClient");
  formData.append("client_secret", "86d677d3-ffee-4a6d-85ab-e000894768e6");
  formData.append("scope", "GatewayServiceAPI");
  formData.append("userName", userName);
  formData.append("password", password);

  return await fetch(`https://localhost:7292/connect/token`, {
    method: "POST",
    headers: {
      // "Content-Type": "application/json; charset=utf-8",
      "Content-Type": "application/x-www-form-urlencoded",
    },
    body: formData.toString(),
    json: true,
  })
    .then(handleHttpErrors)
    .then((res) => {
      console.log(res);
      setToken(res.access_token);
    });
}
const fetchAllRest = () => {
  const options = makeOptions("GET", true);
  return fetch("https://localhost:7236/Gateway/restaurants", options).then(handleHttpErrors);
};

const fetchMenuByRestId = (restId) => {
  const options = makeOptions("GET", true);

  return fetch("https://localhost:7236/Gateway/" + restId + "/menu-from-restaurant", options).then(handleHttpErrors);
};

const createOrder = (order) => {
  const options = makeOptions("POST", true, order);
  return fetch("https://localhost:7236/Gateway/order", options).then(handleHttpErrors);
};

const register = (registerCredentials) => {
  const options = makeOptions("POST", true, registerCredentials);
  return fetch("https://localhost:7236/Gateway/register", options).then(handleHttpErrors);

}

const getEmail = () => {
  let myToken = getToken();
  let tokenData = myToken.split(".")[1];
  let decoedeJsonData = window.atob(tokenData);
  let decodedJwtData = JSON.parse(decoedeJsonData);
  let email = decodedJwtData.Email;
  console.log(email);

  return email;
};
const getRole = () => {
  let myToken = getToken();
  let tokenData = myToken.split(".")[1];
  let decoedeJsonData = window.atob(tokenData);
  let decodedJwtData = JSON.parse(decoedeJsonData);
  let role = decodedJwtData.roles;

  return role;
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
    opts.headers["Authorization"] = `Bearer ${getToken()}`;
  }
  if (body) {
    opts.body = JSON.stringify(body);
  }
  return opts;

  
};

var facade = {
  login,
  logout,
  fetchAllRest,
  fetchMenuByRestId,
  getEmail,
  createOrder,
  register
};

export { facade };
