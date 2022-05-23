import './App.css';
import Header from "./Components/Header";
import Customer from "./Components/Customer"
import Login from "./Components/Login"
import Owner from "./Components/Owner"
import Register from "./Components/Register"
import Restaurants from "./Components/Restaurants"
import RestaurantMenu from "./Components/RestaurantMenu"
import {
  Routes,
  Route
} from "react-router-dom";
function App() {
  return (
    
      <div>
        <Header />
          <Routes>
        <Route path='/restaurants' element={<Restaurants/>} />
        <Route path='/login' element={<Login/>} />
        <Route path='/register' element={<Register/>} />
        <Route path='/' element={<Customer/>} />

          </Routes>       
      </div>
    );
  }
  export default App;
