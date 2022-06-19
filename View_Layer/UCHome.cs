using System.Windows.Forms;

namespace UI.View_Layer
{
    public partial class UCHome : UserControl
    {
        public UCHome()
        {
            InitializeComponent();
        }

        private void UCHome_Load(object sender, System.EventArgs e)
        {
            BS_Layer.BLDanhSachUngTuyen dbDSUT=new BS_Layer.BLDanhSachUngTuyen();
            BS_Layer.BLBangTinTuyenSinh dbBTTS = new BS_Layer.BLBangTinTuyenSinh();
            BS_Layer.BLNganhDaoTao dbNgDT = new BS_Layer.BLNganhDaoTao();
            BS_Layer.BLChuongTrinhDaoTao dbCTDT = new BS_Layer.BLChuongTrinhDaoTao();

            lbInfor1.Text = dbDSUT.DemSoTSTrungTuyen().ToString();
            lbInfor2.Text = dbBTTS.DemSoTinTS().ToString();
            lbInfor3.Text = dbNgDT.DemSoNganh().ToString();
            lbInfor4.Text = dbDSUT.DemSoDonUT().ToString();

            chartMenu.Series["Khoa"].Points[0].SetValueY(dbCTDT.DemNganh("Cơ Khí Chế Tạo Máy"));
            chartMenu.Series["Khoa"].Points[1].SetValueY(dbCTDT.DemNganh("Cơ Khí Động Lực"));
            chartMenu.Series["Khoa"].Points[2].SetValueY(dbCTDT.DemNganh("Công Nghệ Hóa Học Và Thực Phẩm"));
            chartMenu.Series["Khoa"].Points[3].SetValueY(dbCTDT.DemNganh("Công Nghệ Thông Tin"));
            chartMenu.Series["Khoa"].Points[4].SetValueY(dbCTDT.DemNganh("Đào Tạo Chất Lượng Cao"));
            chartMenu.Series["Khoa"].Points[5].SetValueY(dbCTDT.DemNganh("Điện - Điện Tử"));
            chartMenu.Series["Khoa"].Points[6].SetValueY(dbCTDT.DemNganh("In - Truyền Thông"));
            chartMenu.Series["Khoa"].Points[7].SetValueY(dbCTDT.DemNganh("Khoa Học Ứng Dụng"));
            chartMenu.Series["Khoa"].Points[8].SetValueY(dbCTDT.DemNganh("Kinh Tế"));
            chartMenu.Series["Khoa"].Points[9].SetValueY(dbCTDT.DemNganh("Chính Trị Và Luật"));
            chartMenu.Series["Khoa"].Points[10].SetValueY(dbCTDT.DemNganh("Ngoại Ngữ"));
            chartMenu.Series["Khoa"].Points[11].SetValueY(dbCTDT.DemNganh("Xây Dựng"));
            chartMenu.Series["Khoa"].Points[12].SetValueY(dbCTDT.DemNganh("Thời Trang Và Du Lịch"));
            chartMenu.Series["Khoa"].Points[13].SetValueY(dbCTDT.DemNganh("Viện Sư Phạm Kỹ Thuật"));
            chartMenu.Series["Khoa"].Points[14].SetValueY(dbCTDT.DemNganh("Khoa Đào Tạo Quốc Tế"));

        }
    }
}
