import axios from "axios";
import Cookies from "js-cookie";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { SignUpPage, SignInPage, TodayPage, ProjectPage, Test } from "./Pages";

function App() {
    const TOKEN = Cookies.get("TOKEN");
    const checkAuth = Boolean(TOKEN);

    axios.defaults.headers.common["Authorization"] = `Bearer ${TOKEN}`;

    axios.defaults.baseURL = process.env.REACT_APP_BASE_URL;

    return (
        <div className="App">
            <Router>
                <Routes>
                    <Route path="/" element={<SignInPage />} />
                    <Route path="/signup" element={<SignUpPage />} />
                    <Route
                        path="/app/today"
                        element={checkAuth ? <TodayPage /> : <SignInPage />}
                    />
                    <Route
                        path="/app/project/:projectId"
                        element={checkAuth ? <ProjectPage /> : <SignInPage />}
                    />
                    <Route path="/test" element={<Test />} />
                </Routes>
            </Router>
        </div>
    );
}

export default App;
