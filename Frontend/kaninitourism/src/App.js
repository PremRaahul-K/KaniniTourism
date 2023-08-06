import { BrowserRouter, Routes, Route } from "react-router-dom";
import "./App.css";
import Login from "./components/Login/Login";
import Navbar from "./components/Navbar/Navbar";
import Home from "./components/Home/Home";
import Admin from "./components/Admin/Admin";
import Addtourdetails from "./components/AddTour/Addtourdetails";
import TravelAgentRegister from "./components/TravelAgentRegister/TravelAgentRegister";
import TravellerRegister from "./components/TravellerRegister/TravellerRegister";
import Traveller from "./components/Traveller/Traveller";
import Agent from "./components/Agent/Agent";
import TourPackage from "./components/TourPackage/TourPackage";
import Package from "./components/Packages/Package";
import UserHome from "./components/UserHome/UserHome";

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Routes>
          <Route path="/login" element={<Login />} />
          <Route path="/navbar" element={<Navbar />} />
          <Route path="/agent" element={<Agent />} />
          <Route path="/addtourdetails" element={<Addtourdetails />} />
          <Route path="/admin" element={<Admin />} />
          <Route path="/traveller/*" element={<Traveller />} />
          <Route path="/package" element={<Package />} />
          <Route path="/tourpackage" element={<TourPackage />} />
          <Route path="/userhome" element={<UserHome />} />
          <Route
            path="/travelagentregister"
            element={<TravelAgentRegister />}
          />
          <Route path="/travellerregister" element={<TravellerRegister />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
