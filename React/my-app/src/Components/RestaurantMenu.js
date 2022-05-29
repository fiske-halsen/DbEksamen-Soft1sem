import {
    NavLink,
    useParams,
  } from 'react-router-dom';
  import React, { useState, useEffect } from "react";
  import {facade} from "../apiFacade.js";


function RestaurantMenu(){
    const { restaurantId } = useParams();
    const [menu, setMenu] = useState({menu: []});
    const [orderItems, setOrderItems] = useState([])
    const [restaurants, setRestaurants] = useState([])
    const [restaurantName, setRestaurantName] = useState("")
    const [restaurantType, setRestaurantType] = useState("")


useEffect(() => {
    console.log("DILLER")
    facade.fetchAllRest().then((data) => {
        setRestaurants(data)
      });
  }, []);

    
    function addToOrder(e){
        e.preventDefault()
        let menuItemName = e.currentTarget.id
        menu.menu.forEach((x) => {
            if(x.menuItemName === menuItemName){
                setOrderItems([
                    ...orderItems, {
                        "menuItemName": x.menuItemName,
                        "price": x.price,
                        "menuItemType": x.menuItemType
                    }
                ])
            }
        } )
        console.log(orderItems)
    }
    function order (){
        restaurants.forEach((x) => {
            if(x.id == restaurantId){
                console.log("HER MAND: " + x.id + "    " + restaurantId)
                setRestaurantName(x.restaurantName)
                setRestaurantType(x.restaurantType)
                
            }
        })


        let customerEmail = facade.getEmail()
        facade.createOrder({
            customerEmail: customerEmail,
            restaurantName: restaurantName,
            restaurantType: restaurantType,
            restaurantId: restaurantId,
            items: orderItems
            
          })
    }
    
    
    useEffect(() => {
        facade.fetchMenuByRestId(restaurantId).then((data) => {
            setMenu(data)
          });
      }, [restaurantId]);
    return(
        <div>
        <table className="table">
        <thead>
          <tr>
            <th>Navn</th>
            <th>Pris</th>
            <th>Type</th>
          </tr>
          {menu.menu.map((menuItem) => (
            <tr key={menuItem.menuItemName}>
              <td>{menuItem.menuItemName}</td>
              <td>{menuItem.price}</td>
              <td>{menuItem.menuItemType}</td>
              <td>
                  <button id = {menuItem.menuItemName} onClick = {addToOrder}>Add To Order </button>
              </td>
              
            </tr>
          ))}
        </thead>
        <tbody>{/*Add the rows here */}</tbody>
      </table>
      <button onClick = {order} >Bestil</button>
      <h2>Din Ordre:</h2>
      <table className="table">
        <thead>
          <tr>
            <th>Navn</th>
            <th>Pris</th>
            <th>Type</th>
          </tr>
          {orderItems.map((menuItem) => (
            <tr key={menuItem.menuItemName}>
              <td>{menuItem.menuItemName}</td>
              <td>{menuItem.price}</td>
              <td>{menuItem.menuItemType}</td>
              <td>
              </td>
              
            </tr>
          ))}
        </thead>
        <tbody>{/*Add the rows here */}</tbody>
      </table>

        </div>
    )
}


export default RestaurantMenu;