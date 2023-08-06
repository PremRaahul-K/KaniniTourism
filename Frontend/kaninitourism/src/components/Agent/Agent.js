import React from "react";
import "../Agent/Agent.css";
import Addtourdetails from "../AddTour/Addtourdetails";
import AgentNavbar from "../AgentNavbar/AgentNavbar";

function Agent() {
  return (
    <div className="Agent">
      <div className="AgentNavbar">
        <AgentNavbar />
      </div>
      <div className="AgentContent">
        <Addtourdetails />
      </div>
    </div>
  );
}

export default Agent;
