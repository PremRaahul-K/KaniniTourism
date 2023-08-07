import { BrowserRouter, Routes, Route } from "react-router-dom";
import "./App.css";
import Login from "./components/Login/Login";
import Admin from "./components/Admin/Admin";
import TravelAgentRegister from "./components/TravelAgentRegister/TravelAgentRegister";
import TravellerRegister from "./components/TravellerRegister/TravellerRegister";
import Traveller from "./components/Traveller/Traveller";
import Agent from "./components/Agent/Agent";
import ViewAgents from "./components/ViewAgents/ViewAgents";

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Routes>
          <Route path="/login" element={<Login />} />
          <Route path="/agent/*" element={<Agent />} />
          <Route path="/admin/*" element={<Admin />} />
          <Route path="/traveller/*" element={<Traveller />} />
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
