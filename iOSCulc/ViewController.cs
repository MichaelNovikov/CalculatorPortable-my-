using CalculatorPortable;
using Foundation;
using System;
using UIKit;

namespace iOSCulc
{
    public partial class ViewController : UIViewController
    {
        CalcPresenter calcPresenter;

        public ViewController (IntPtr handle) : base (handle)
        {
            calcPresenter = new CalcPresenter();
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.

            btn0.TouchUpInside += AnyButton_TouchUpInside;
            btn1.TouchUpInside += AnyButton_TouchUpInside;
            btn2.TouchUpInside += AnyButton_TouchUpInside;
            btn3.TouchUpInside += AnyButton_TouchUpInside;
            btn4.TouchUpInside += AnyButton_TouchUpInside;
            btn5.TouchUpInside += AnyButton_TouchUpInside;
            btn6.TouchUpInside += AnyButton_TouchUpInside;
            btn7.TouchUpInside += AnyButton_TouchUpInside;
            btn8.TouchUpInside += AnyButton_TouchUpInside;
            btn9.TouchUpInside += AnyButton_TouchUpInside;
            btnC.TouchUpInside += AnyButton_TouchUpInside;
            btnDot.TouchUpInside += AnyButton_TouchUpInside;
            btnPlus.TouchUpInside += AnyButton_TouchUpInside;
            btnMinus.TouchUpInside += AnyButton_TouchUpInside;
            btnMul.TouchUpInside += AnyButton_TouchUpInside;
            btnDiv.TouchUpInside += AnyButton_TouchUpInside;
            btnEqual.TouchUpInside += AnyButton_TouchUpInside;

        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        private void AnyButton_TouchUpInside(object sender, EventArgs e)
        {
            UIButton btn = sender as UIButton;
            string textV = mainLable.Text, textVOp =signLabel.Text;

            calcPresenter.Present(ref textV, ref textVOp, btn.Title(UIControlState.Normal));

            mainLable.Text = textV;
            signLabel.Text = textVOp;
        }
    }
}