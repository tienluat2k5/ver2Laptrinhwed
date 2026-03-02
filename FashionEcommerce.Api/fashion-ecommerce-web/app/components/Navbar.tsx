"use client";

import Link from "next/link";
import { useAuth } from "../context/AuthContext";

export default function Navbar() {
  const { token, logout } = useAuth();

  return (
    <nav className="flex justify-between px-10 py-4 bg-white shadow">
      <h1 className="font-bold text-xl">FASHION</h1>

      <div className="flex gap-6 items-center">
        <Link href="/">Home</Link>
        <Link href="/products">Shop</Link>

        {token && <Link href="/cart">Cart</Link>}

        {!token ? (
          <>
            <Link href="/login">Login</Link>
            <Link href="/register">Register</Link>
          </>
        ) : (
          <button
            onClick={logout}
            className="bg-black text-white px-3 py-1 rounded"
          >
            Logout
          </button>
        )}
      </div>
    </nav>
  );
}