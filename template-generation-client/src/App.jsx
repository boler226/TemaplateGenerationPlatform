import './App.css'
import { Routes, Route, Navigate } from "react-router-dom";
import TemplatesPage from "./pages/template/TemplatesPage.tsx";

function App() {

  return (
      <Routes>
        <Route path="/" element={<TemplatesPage />} />
        <Route path="*" element={<Navigate to="/" />} />
      </Routes>
  )
}

export default App
