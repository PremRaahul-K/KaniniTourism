import React, { useState } from "react";
import "../TravelAgentRegister/TravelAgentRegister.css";
import { useNavigate } from "react-router-dom";
import Traveller from "../images/TravellerImage.png";
function TravelAgentRegister() {
  const navigate = useNavigate();
  var [user, setUser] = useState({
    email: "",
    password: "",
  });
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [emailError, setEmailError] = useState("");
  const [passwordError, setPasswordError] = useState("");

  const validateEmail = () => {
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailPattern.test(user.email)) {
      setEmailError("Please enter a valid email address");
      return false;
    }
    setEmailError("");
    return true;
  };

  const validatePassword = () => {
    if (user.password.length < 4) {
      setPasswordError("Password must be at least 8 characters long");
      return false;
    }
    setPasswordError("");
    return true;
  };

  const handleSubmit = () => {
    if (validateEmail() && validatePassword()) {
      fetch("http://localhost:5115/api/User/Login", {
        method: "POST",
        headers: {
          accept: "text/plain",
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ ...user }),
      })
        .then(async (data) => {
          var myData = await data.json();
          localStorage.setItem("id", myData.id);
          localStorage.setItem("role", myData.role);
          localStorage.setItem("token", myData.token);
          if (myData.role == "Traveller") {
            if (myData.token != null) {
              navigate("/main");
            }
          } else if (myData.role == "TravelAgent") {
            navigate("/addtourdetails");
          } else if (myData.role == "Admin") {
            navigate("/admin");
          }
        })
        .catch((err) => {
          console.log(err.error);
        });
    }
  };
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
            <h2 className="MakeYourTripLogo">MakeYourTrip</h2>
          </div>
          <div className="UserCredentials">
            <span className="SignInLabel">Sign In</span>
            <span className="SignInMessage">
              Welcome back! Please enter email id and password
            </span>
          </div>
          <div className="UserCredentials">
            <label className="LoginInputLabel">Email ID</label>
            <input
              type="email"
              className="LoginInputField"
              // value={email}
              // onChange={(e) => setEmail(e.target.value)}
              onBlur={validateEmail}
              placeholder="Email"
              onChange={(event) => {
                setUser({ ...user, email: event.target.value });
              }}
            />
            {emailError && <span className="ErrorText">{emailError}</span>}
            <label className="LoginInputLabel">Password</label>
            <input
              type="password"
              className="LoginInputField"
              // value={password}
              // onChange={(e) => setPassword(e.target.value)}
              onBlur={validatePassword}
              placeholder="Password"
              onChange={(event) => {
                setUser({ ...user, password: event.target.value });
              }}
            />
            {passwordError && (
              <span className="ErrorText">{passwordError}</span>
            )}
            <button className="SignInButton" onClick={handleSubmit}>
              SIGN IN
            </button>
            <div className="SignUpButtons">
              <button className="SignUpButton">Traveller SignUp</button>
              <button className="SignUpButton">Travelagent SignUp</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default TravelAgentRegister;
