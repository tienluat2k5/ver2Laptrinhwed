import Navbar from './components/Navbar'; 
import ProductCard from './components/ProductCard';

async function getProducts() {
  try {
    const res = await fetch('http://localhost:5220/api/Products', { cache: 'no-store' });
    if (!res.ok) return [];
    return res.json();
  } catch (error) {
    return [];
  }
}

export default async function Home() {
  const products = await getProducts();

  return (
    <main className="min-h-screen bg-gray-50">
      <Navbar />
      {/* Hero Banner */}
      <section className="relative w-full h-[500px] bg-black flex items-center justify-center">
        <div className="relative z-10 text-center text-white px-4">
          <h1 className="text-5xl md:text-7xl font-black uppercase tracking-tighter italic">
            Bứt Phá <span className="text-red-600">Giới Hạn</span>
          </h1>
          <button className="mt-8 bg-red-600 hover:bg-red-700 text-white font-bold py-3 px-10 rounded-full transition-transform transform hover:scale-105 uppercase">
            Săn Sale Ngay
          </button>
        </div>
      </section>

      {/* Sản phẩm tiêu biểu ở trang chủ */}
      <section className="container mx-auto px-4 py-16">
        <h2 className="text-3xl font-black uppercase mb-10 text-center italic">Hàng Mới Về</h2>
        <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-4 gap-6">
          {products.slice(0, 4).map((p: any) => (
            <ProductCard key={p.id} product={p} />
          ))}
        </div>
      </section>
    </main>
  );
}