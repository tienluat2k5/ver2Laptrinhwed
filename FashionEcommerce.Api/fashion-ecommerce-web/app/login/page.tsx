"use client";

import { useState } from 'react';
import { useRouter } from 'next/navigation';
import Link from 'next/link'; // BẮT BUỘC PHẢI THÊM THẰNG NÀY ĐỂ CHUYỂN TRANG
import Navbar from '../components/Navbar';

export default function LoginPage() {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const router = useRouter();

  const handleLogin = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');

    try {
      const res = await fetch('http://localhost:5220/api/Auth/Login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, password }),
      });

      if (res.ok) {
        const data = await res.json();
        localStorage.setItem('token', data.token);
        alert('Đăng nhập thành công, chào mừng mài!');
        router.push('/');
      } else {
        setError('Sai tài khoản hoặc mật khẩu cmnr!');
      }
    } catch (err) {
      setError('Lỗi kết nối đến Server. Bật Backend lên chưa mài?');
    }
  };

  return (
    <div className="min-h-screen bg-gray-50">
      <Navbar />
      <div className="flex items-center justify-center py-20 px-4">
        <div className="bg-white p-8 rounded-2xl shadow-lg max-w-md w-full border border-gray-100">
          <h2 className="text-3xl font-black uppercase mb-6 text-center italic">Đăng Nhập</h2>
          
          {error && (
            <div className="bg-red-100 text-red-600 p-3 rounded mb-4 text-sm font-bold text-center">
              {error}
            </div>
          )}

          <form onSubmit={handleLogin} className="space-y-5">
            <div>
              <label className="block text-sm font-bold mb-2 uppercase text-gray-700">Tài Khoản</label>
              <input 
                type="text" 
                className="w-full border-2 border-gray-200 p-3 rounded-xl outline-none focus:border-black transition-colors"
                placeholder="Nhập username..."
                value={username}
                onChange={(e) => setUsername(e.target.value)}
                required
              />
            </div>
            
            <div>
              <label className="block text-sm font-bold mb-2 uppercase text-gray-700">Mật Khẩu</label>
              <input 
                type="password" 
                className="w-full border-2 border-gray-200 p-3 rounded-xl outline-none focus:border-black transition-colors"
                placeholder="••••••••"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                required
              />
              
              {/* NÚT QUÊN MẬT KHẨU NẰM ĐÂY */}
              <div className="flex justify-end mt-2">
                <Link href="/forgot-password" className="text-sm font-bold text-gray-500 hover:text-red-600 transition-colors">
                  Quên mật khẩu?
                </Link>
              </div>
            </div>

            <button 
              type="submit" 
              className="w-full bg-red-600 text-white font-bold py-3 rounded-xl uppercase hover:bg-red-700 transition-colors shadow-md"
            >
              Vào Việc
            </button>

            {/* NÚT ĐĂNG KÝ NẰM DƯỚI CÙNG */}
            <div className="mt-6 border-t pt-6 text-center text-sm text-gray-600 font-medium">
              Chưa có tài khoản?{' '}
              <Link href="/register" className="font-black text-red-600 hover:text-black transition-colors uppercase tracking-wide">
                Đăng Ký Ngay
              </Link>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}