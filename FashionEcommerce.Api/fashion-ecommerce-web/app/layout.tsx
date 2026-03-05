import './globals.css';

export const metadata = {
  title: 'Supersports - Mua Giày Thể Thao',
  description: 'Trang web bán đồ thể thao xịn xò nhất',
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="vi">
      <body>{children}</body>
    </html>
  );
}