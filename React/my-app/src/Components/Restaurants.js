import React, { useState, useEffect } from "react";
import {facade} from "../apiFacade.js";
import { URL } from "../settings";

import RestaurantMenu from "./RestaurantMenu.js";
import { Routes, Route, Link, Outlet, NavLink } from 'react-router-dom';

function Restaurant({fetchAllRest}){
const [restaurants, setRestaurants] = useState([])
useEffect(() => {
    console.log("DILLER")
    facade.fetchAllRest().then((data) => {
        setRestaurants(data)
      });
  }, []);
    




    return(
        <div>
       <table className="table">
        <thead>
          <tr>
            <th>Navn</th>
            <th>Type</th>
            <th>Gade</th>
            <th>By</th>
            <th>Zip</th>
          </tr>
          {restaurants.map((restaurant) => (
            <tr key={restaurant.id}>
              <td>{restaurant.restaurantName} </td>
              <td>{restaurant.restaurantType}</td>
              <td>{restaurant.streetName}</td>
              <td>{restaurant.city}</td>
              <td>{restaurant.zipCode}</td>
              <td>
                  <button><NavLink to={"/restaurants/" + restaurant.id}>View Menu</NavLink></button>
              </td>
            </tr>
          ))}
        </thead>
        <tbody>{/*Add the rows here */}</tbody>
      </table>
      <Outlet/>
    </div>
    );
}


export default Restaurant;