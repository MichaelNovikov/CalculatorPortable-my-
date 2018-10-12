using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using CalculatorPortable;

namespace DroidCulc
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView textView;
        TextView txtViewOper;
        CalcPresenter calcPresenter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            calcPresenter = new CalcPresenter(new Validator(), new FuncSelector(new Calculator()));

            textView = FindViewById<TextView>(Resource.Id.txtV);
            txtViewOper = FindViewById<TextView>(Resource.Id.txtViewOp);

            var btn0 = FindViewById<Button>(Resource.Id.btn0);
            var btn1 = FindViewById<Button>(Resource.Id.btn1);
            var btn2 = FindViewById<Button>(Resource.Id.btn2);
            var btn3 = FindViewById<Button>(Resource.Id.btn3);
            var btn4 = FindViewById<Button>(Resource.Id.btn4);
            var btn5 = FindViewById<Button>(Resource.Id.btn5);
            var btn6 = FindViewById<Button>(Resource.Id.btn6);
            var btn7 = FindViewById<Button>(Resource.Id.btn7);
            var btn8 = FindViewById<Button>(Resource.Id.btn8);
            var btn9 = FindViewById<Button>(Resource.Id.btn9);
            var btnDot = FindViewById<Button>(Resource.Id.btnDot);

            var btnPlus = FindViewById<Button>(Resource.Id.btnPlus);
            var btnMinus = FindViewById<Button>(Resource.Id.btnMinus);
            var btnMul = FindViewById<Button>(Resource.Id.btnMul);
            var btnDiv = FindViewById<Button>(Resource.Id.btnDiv);
            var btnEquel = FindViewById<Button>(Resource.Id.btnEquel);
            var btnC = FindViewById<Button>(Resource.Id.btnC);

            btn0.Click += AnyButton_Click;
            btn1.Click += AnyButton_Click;
            btn2.Click += AnyButton_Click;
            btn3.Click += AnyButton_Click;
            btn4.Click += AnyButton_Click;
            btn5.Click += AnyButton_Click;
            btn6.Click += AnyButton_Click;
            btn7.Click += AnyButton_Click;
            btn8.Click += AnyButton_Click;
            btn9.Click += AnyButton_Click;
            btnDot.Click += AnyButton_Click;
            btnPlus.Click += AnyButton_Click;
            btnMinus.Click += AnyButton_Click;
            btnMul.Click += AnyButton_Click;
            btnDiv.Click += AnyButton_Click;
            btnEquel.Click += AnyButton_Click;
            btnC.Click += AnyButton_Click;
        }

        private void AnyButton_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            string textV = textView.Text, textVOp = txtViewOper.Text;

            calcPresenter.Present(ref textV, ref textVOp, b.Text);

            textView.Text = textV;
            txtViewOper.Text = textVOp;
        }
    }
}

