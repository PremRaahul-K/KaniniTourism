import { BrowserRouter, Routes, Route } from "react-router-dom";
import "./App.css";
import Login from "./components/Login/Login";
import Admin from "./components/Admin/Admin";
import TravelAgentRegister from "./components/TravelAgentRegister/TravelAgentRegister";
import TravellerRegister from "./components/TravellerRegister/TravellerRegister";
import Traveller from "./components/Traveller/Traveller";
import Agent from "./components/Agent/Agent";
import Home from "./components/Home/Home";
import AgentProtected from "./components/Protected/AgentProtected";
import AdminProtected from "./components/Protected/AdminProtected";
import TravellerProtected from "./components/Protected/TravellerProtected";

function App() {
  var token;
  return (
    <div className="App">
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route
            path="/agent/*"
            element={
              <AgentProtected token={token}>
                <Agent />
              </AgentProtected>
            }
          />
          <Route
            path="/admin/*"
            element={
              <AdminProtected token={token}>
                <Admin />
              </AdminProtected>
            }
          />
          <Route
            path="/traveller/*"
            element={
              <TravellerProtected token={token}>
                <Traveller />
              </TravellerProtected>
            }
          />
          <Route path="/login" element={<Login />} />
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
