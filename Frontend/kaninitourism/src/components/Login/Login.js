import React from "react";
import "../Login/Login.css";
import Traveller from "../images/TravellerImage.png";
import KaniniLogo from "../images/KaniniLogo.svg";

function Login() {
  return (
    <div className="Login">
      <div className="LoginMessage">
        <div>
          <img src={Traveller} className="Traveller" />
        </div>
        <div className="LoginNote">
          <span className="LoginWelcomeMessage">Welcome back!</span>
          <span className="SignInMessage">
            Please sign in to your account to continue exploring the world with
            our amazing travel deals and services. Your next adventure awaits!
          </span>
        </div>
      </div>
      <div className="LoginCredentials">
        <div className="UserCredentials">
          <div>
            <img src={KaniniLogo} className="KaniniLogo" />
          </div>
          <div className="UserCredentials">
            <span className="SignInLabel">Sign In</span>
            <span className="SignInMessage">
              Welcome back! Please enter email id and password
            </span>
          </div>
          <div className="UserCredentials">
            <label className="LoginInputLabel">Email ID</label>
            <input type="email" className="LoginInputField" />
            <label className="LoginInputLabel">Password</label>
            <input type="password" className="LoginInputField" />
            <button className="SignInButton">SIGN IN</button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Login;
