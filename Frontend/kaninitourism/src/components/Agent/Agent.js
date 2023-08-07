import React, { useState } from "react";
import "../Agent/Agent.css";
import Addtourdetails from "../AddTour/Addtourdetails";
import { Route, Routes } from "react-router-dom";
import { Link } from "react-router-dom";
import { AiOutlineMenu } from "react-icons/ai";
import { MdCancel } from "react-icons/md";

function Agent() {
  const [toggleDropDown, setDropDown] = useState(false);
  return (
    <div className="Agent">
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
                  <Link className="link" to="/agent/tourpackages">
                    Tour Packages
                  </Link>
                </li>
                <li className="navButton">
                  <Link className="link" to="/agent/createpackage">
                    Create Package
                  </Link>
                </li>
                <li className="navButton">
                  <Link className="link" to="/login">
                    Profile
                  </Link>
                </li>
                <li className="navButton">
                  <Link className="link" to="/login">
                    View Bookings
                  </Link>
                </li>
              </ul>
              <Link to="" className="action_btn link">
                Logout
              </Link>
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
                <Link className="link" to="/login">
                  TourPackages
                </Link>
              </li>
              <li>
                <Link className="link" to="/login">
                  Create Package
                </Link>
              </li>
              <li className="link">
                <Link className="link" to="/login">
                  Profile
                </Link>
              </li>
              <li>
                <Link className="link" to="/login">
                  View Bookings
                </Link>
              </li>
              <li>
                <Link to="/login" className="action_btn link">
                  Logout
                </Link>
              </li>
            </div>
          </header>
        </div>{" "}
      </div>
      <div className="AgentContent">
        <Routes>
          <Route path="createpackage" element={<Addtourdetails />} />
        </Routes>
      </div>
    </div>
  );
}

export default Agent;
