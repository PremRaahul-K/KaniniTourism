import React from "react";
import "../Sidebar/Sidebar.css";
import { useState, Link } from "react";
import TravellerLogo from "../images/PersonLogo.jpg";
import { useNavigate } from "react-router-dom";

function Sidebar() {
  const navigate = useNavigate();
  const [sidebarClosed, setSidebarClosed] = useState(false);

  return (
    <div className="Sidebar">
      <nav className={sidebarClosed ? "sidebar" : " sidebar close"}>
        <header>
          <div className="image-text">
            <span className="image">
              <img src={TravellerLogo} alt="" />
            </span>

            <div className="text logo-text">
              <span className="name">Kanini Tourism</span>
              <span className="profession">prem@gmail.com</span>
            </div>
          </div>
          <i
            className="bx bx-chevron-right toggle"
            onClick={() => {
              setSidebarClosed(!sidebarClosed);
            }}
          ></i>
        </header>

        <div className="menu-bar">
          <div className="menu">
            <ul className="menu-links">
              <li className="nav-link">
                <div className="navItem">
                  <i class="bi bi-house-door icon"></i>
                  <span className="text nav-text">Home</span>
                </div>
              </li>

              <li className="nav-link">
                <div className="navItem">
                  <i class="bi bi-clock-history icon"></i>{" "}
                  <span className="text nav-text">History</span>
                </div>
              </li>

              <li className="nav-link">
                <div className="navItem">
                  <i className="bi bi-heart icon"></i>
                  <span className="text nav-text">Likes</span>
                </div>
              </li>

              <li className="nav-link">
                <div className="navItem">
                  <i class="bi bi-wallet2 icon"></i>
                  <span className="text nav-text">Wallets</span>
                </div>
              </li>
            </ul>
          </div>

          <div className="bottom-content">
            <div
              className="logoutContainer"
              onClick={() => {
                localStorage.clear();
                navigate("/");
              }}
            >
              <li className="navItem">
                <i className="bi bi-box-arrow-left icon"></i>
                <span className="text nav-text">Logout</span>
              </li>
            </div>
          </div>
        </div>
      </nav>
    </div>
  );
}

export default Sidebar;
