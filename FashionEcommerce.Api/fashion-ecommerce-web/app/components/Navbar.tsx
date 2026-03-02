"use client";

import Link from "next/link";

export default function Navbar() {
  return (
    <nav className="w-full bg-white shadow-md fixed top-0 z-50">
      <div className="max-w-7xl mx-auto flex justify-between items-center px-8 py-4">
        <Link href="/" className="text-2xl font-bold tracking-wide">
          FASHION
        </Link>

        <div className="space-x-8 text-lg">
          <Link href="/" className="hover:text-gray-500 transition">
            Home
          </Link>
          <Link href="/products" className="hover:text-gray-500 transition">
            Shop
          </Link>
          <Link href="/cart" className="hover:text-gray-500 transition">
            Cart
          </Link>
        </div>
      </div>
    </nav>
  );
}