"use client";

import { useState } from "react";
import { useRouter } from "next/navigation";

export default function RegisterPage() {
  const router = useRouter();

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleRegister = async () => {
    const res = await fetch("https://localhost:5001/api/auth/register", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ email, password }),
    });

    if (res.ok) {
      alert("Register success!");
      router.push("/login");
    } else {
      alert("Register failed");
    }
  };

  return (
    <div className="h-screen flex items-center justify-center">
      <div className="bg-white p-8 shadow-lg rounded w-96">
        <h2 className="text-2xl font-bold mb-6 text-center">Register</h2>

        <input
          className="border w-full p-2 mb-4"
          placeholder="Email"
          onChange={(e) => setEmail(e.target.value)}
        />

        <input
          type="password"
          className="border w-full p-2 mb-4"
          placeholder="Password"
          onChange={(e) => setPassword(e.target.value)}
        />

        <button
          onClick={handleRegister}
          className="w-full bg-black text-white py-2 rounded"
        >
          Register
        </button>
      </div>
    </div>
  );
}