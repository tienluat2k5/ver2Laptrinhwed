import Navbar from '../components/Navbar';
import ProductCard from '../components/ProductCard';

async function getProducts(search = '') {
  try {
    // Gọi đến API .NET của mày [cite: 6]
    const res = await fetch(`http://localhost:5220/api/Products?search=${search}`, { cache: 'no-store' });
    if (!res.ok) return [];
    return res.json();
  } catch (error) {
    console.error("Lỗi gọi API:", error);
    return [];
  }
}

// Sửa lại định nghĩa: Bỏ dấu ? ở searchParams đi, để nó là object bắt buộc
export default async function AllProductsPage({ 
  searchParams 
}: { 
  searchParams: { search?: string } 
}) {
  
  // Bản 14 thì dùng trực tiếp luôn, không cần await cái searchParams này
  const currentSearch = searchParams?.search || '';
  const products = await getProducts(currentSearch);

  return (
    <div className="min-h-screen bg-gray-50">
      <Navbar />
      <div className="container mx-auto px-4 py-8 flex flex-col md:flex-row gap-8">
        
        {/* BỘ LỌC (Sidebar) */}
        <aside className="w-full md:w-1/4 bg-white p-6 rounded-xl shadow-sm h-fit sticky top-20">
          <h3 className="font-black text-xl uppercase mb-6 border-b pb-2">Bộ Lọc</h3>
          <div className="mb-8">
            <h4 className="font-bold mb-4 text-red-600 uppercase text-xs">Kích Cỡ (Size)</h4>
            <div className="grid grid-cols-3 gap-2">
              {['38', '39', '40', '41', '42', '43'].map(size => (
                <button key={size} className="border border-gray-200 p-2 text-sm font-bold hover:bg-black hover:text-white transition-all uppercase">
                  {size}
                </button>
              ))}
            </div>
          </div>
          <div>
            <h4 className="font-bold mb-4 text-red-600 uppercase text-xs">Khoảng Giá</h4>
            <div className="flex flex-col gap-3 text-sm font-medium">
              <label className="flex items-center gap-2 cursor-pointer hover:text-red-600">
                <input type="checkbox" className="w-4 h-4 accent-black"/> Dưới 1.000.000đ
              </label>
              <label className="flex items-center gap-2 cursor-pointer hover:text-red-600">
                <input type="checkbox" className="w-4 h-4 accent-black"/> Trên 1.000.000đ
              </label>
            </div>
          </div>
        </aside>

        {/* DANH SÁCH SẢN PHẨM */}
        <div className="w-full md:w-3/4">
          <div className="flex justify-between items-end mb-8">
            <h1 className="text-3xl font-black uppercase italic">Tất Cả Sản Phẩm</h1>
            <p className="text-gray-500 font-medium text-sm">{products.length} sản phẩm</p>
          </div>
          <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
            {products.length > 0 ? (
              products.map((p: any) => (
                <ProductCard key={p.id} product={p} />
              ))
            ) : (
              <div className="col-span-full py-20 text-center bg-white rounded-xl border-2 border-dashed border-gray-200">
                <p className="text-gray-400 font-bold uppercase">Không có sản phẩm nào!</p>
              </div>
            )}
          </div>
        </div>
      </div>
    </div>
  );
}