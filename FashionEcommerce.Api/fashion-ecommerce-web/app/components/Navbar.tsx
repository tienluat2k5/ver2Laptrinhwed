import Link from 'next/link';

export default function Navbar() {
  return (
    <header className="bg-white border-b sticky top-0 z-50">
      <div className="container mx-auto px-4 py-4 flex justify-between items-center">
        
        {/* Logo bên trái */}
        <Link href="/" className="text-2xl font-black uppercase tracking-widest">
          FASHION
        </Link>

        {/* Menu bên phải */}
        <nav className="flex items-center gap-6">
          <Link href="/" className="text-gray-800 hover:text-red-600 font-medium transition-colors">
            Home
          </Link>
          <Link href="/products" className="text-gray-800 hover:text-red-600 font-medium transition-colors">
            Shop
          </Link>
          <Link href="/cart" className="text-gray-800 hover:text-red-600 font-medium transition-colors">
            Cart
          </Link>
          
          {/* Nút Login nổi bật */}
          <Link 
            href="/login" 
            className="bg-black text-white px-6 py-2 rounded-full font-bold text-sm uppercase tracking-wide hover:bg-red-600 transition-all transform hover:scale-105 shadow-md"
          >
            Login
          </Link>
        </nav>
        
      </div>
    </header>
  );
}