import React, { useState } from "react";
import "../Admin/Admin.css";
import { Route, Routes, useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";
import { AiOutlineMenu } from "react-icons/ai";
import { MdCancel } from "react-icons/md";
import ViewAgents from "../ViewAgents/ViewAgents";
import Footer from "../Footer/Footer";

function Admin() {
  const navigate = useNavigate();
  const [toggleDropDown, setDropDown] = useState(false);
  return (
    <div className="Admin">
      <div className="AgentNavbar">
        <div className="Navbar">
          <header className="NavbarHeader">
            <div className="navbar">
              <div className="logo">
                <Link to="/" className="link logoLink">
                  <h2 className="MakeYourTripLogo">MakeYourTrip</h2>
                </Link>
              </div>
              <ul className="links">
                <li className="navButton">
                  <Link className="link" to="/admin/viewagents">
                    View All Agents
                  </Link>
                </li>
              </ul>
              <button
                className="action_btn link"
                onClick={() => {
                  localStorage.clear();
                  navigate("/home");
                }}
              >
                Logout
              </button>
              <div
                className="toggle_btn"
                onClick={() => {
                  setDropDown(!toggleDropDown);
                }}
              >
                {toggleDropDown ? (
                  <MdCancel className="agentNavMenuOption" />
                ) : (
                  <AiOutlineMenu className="agentNavMenuOption" />
                )}
              </div>
            </div>
            <div
              className={
                toggleDropDown ? "dropdown_menu open" : "dropdown_menu"
              }
            >
              <li className="">
                <Link className="link" to="/admin/viewagents">
                  View All Agents
                </Link>
              </li>
              <li>
                <button
                  className="action_btn link"
                  onClick={() => {
                    localStorage.clear();
                    navigate("/");
                  }}
                >
                  Logout
                </button>
              </li>
            </div>
          </header>
        </div>
      </div>
      <div className="AdminContent">
        <Routes>
          <Route path="/viewagents" element={<ViewAgents />} />
        </Routes>
      </div>
      <div>
        <Footer />
      </div>
    </div>
  );
}

export default Admin;
