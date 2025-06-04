import subprocess
import sys


def test_app_output():
    output = subprocess.check_output([sys.executable, "app.py"], text=True)
    assert "Hello, world!" in output
