import { BrowserRouter, Routes, Route } from "react-router-dom";
import "./App.css";
import Login from "./components/Login/Login";
import Main from "./components/Tourism/Main/Main";
import Navbar from "./components/Navbar/Navbar";
import Home from "./components/Home/Home";
import Admin from "./components/Admin/Admin";
import Addtourdetails from "./components/TravelAgent/AddTour/Addtourdetails";
import TravelAgentRegister from "./components/TravelAgentRegister/TravelAgentRegister";

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Routes>
          <Route path="/login" element={<Login />} />
          <Route path="/navbar" element={<Navbar />} />
          <Route path="/main" element={<Main />} />
          <Route path="/" element={<Home />} />
          <Route path="/addtourdetails" element={<Addtourdetails />} />
          <Route path="/admin" element={<Admin />} />
          <Route
            path="/travelagentregister"
            element={<TravelAgentRegister />}
          />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
