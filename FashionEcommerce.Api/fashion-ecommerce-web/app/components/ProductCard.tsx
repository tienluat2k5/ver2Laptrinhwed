import { ShoppingCart } from 'lucide-react';

export default function ProductCard({ product }: { product: any }) {
  // Đề phòng db mày chưa có ảnh/giá, tao setup giá trị mặc định cho nó khỏi văng lỗi
  const imageUrl = product?.imageUrl || "https://images.unsplash.com/photo-1542291026-7eec264c27ff?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80";
  const name = product?.productName || product?.name || "Tên sản phẩm chưa có";
  const price = product?.price || 1500000;

  return (
    <div className="bg-white rounded-xl shadow-sm hover:shadow-xl transition-shadow duration-300 overflow-hidden group cursor-pointer">
      <div className="relative overflow-hidden aspect-square bg-gray-100">
        <img 
          src={imageUrl} 
          alt={name} 
          className="w-full h-full object-cover group-hover:scale-110 transition-transform duration-500"
        />
        <div className="absolute top-3 left-3 bg-red-600 text-white text-xs font-bold px-2 py-1 rounded">
          HOT
        </div>
      </div>
      
      <div className="p-5">
        <h3 className="font-bold text-lg mb-1 truncate">{name}</h3>
        <p className="text-gray-500 text-sm mb-3 uppercase">Supersports</p>
        <div className="flex justify-between items-center">
          <span className="font-black text-xl text-red-600">
            {price.toLocaleString('vi-VN')}đ
          </span>
          <button className="bg-black text-white p-2 rounded-full hover:bg-red-600 transition-colors">
            <ShoppingCart size={20} />
          </button>
        </div>
      </div>
    </div>
  );
}