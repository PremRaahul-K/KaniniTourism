import React, { useState } from "react";
import "../Login/Login.css";
import { useNavigate } from "react-router-dom";
import Traveller from "../images/TravellerImage.png";

function Login() {
  const navigate = useNavigate();
  var [user, setUser] = useState({
    email: "",
    password: "",
  });
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
      setPasswordError("Password must be at least 5 characters long");
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
              navigate("/user");
            }
          } else if (myData.role == "TravelAgent") {
            navigate("/user");
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
          <img src={Traveller} className="TravellerLogo" />
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
              onBlur={validateEmail}
              placeholder="Email"
              onChange={(event) => {
                validateEmail();
                setUser({ ...user, email: event.target.value });
              }}
            />
            {emailError && <span className="ErrorText">{emailError}</span>}
            <label className="LoginInputLabel">Password</label>
            <input
              type="password"
              className="LoginInputField"
              onBlur={validatePassword}
              placeholder="Password"
              onChange={(event) => {
                validatePassword();
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
              <span className="signUpMessage">Don't have an account?</span>
              <button
                className="SignUpButton"
                onClick={() => {
                  navigate("/travellerregister ");
                }}
              >
                Traveller Sign Up
              </button>
              <button
                className="SignUpButton"
                onClick={() => {
                  navigate("/travelagentregister");
                }}
              >
                Travel Agent Sign Up
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Login;
